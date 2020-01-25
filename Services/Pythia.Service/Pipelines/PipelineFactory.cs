using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;
using System.Reflection;
using System.Collections;
using System.Runtime.Remoting;

namespace Pythia.Service.Pipelines
{
    public class DynClassInfo
    {
        public Type type;
        public Object ClassObject;

        public DynClassInfo()
        {
        }

        public DynClassInfo(Type t, ObjectHandle c)
        {
            type = t;
            ClassObject = c.Unwrap();
        }
    }
    public class PipelineFactory
    {
        private Object[] _args;
        private string _pipelineName;
        private List<string> _processors;
        
        private static Hashtable AssemblyReferences = new Hashtable();
        private static Hashtable ClassReferences = new Hashtable();



        public bool WasError { get; set; }
        public string _connectionstring;
        public PipelineFactory()
        {

        }
        public PipelineFactory(string pipelineName, string connectionStringName, Object[] args, string filePath)
        {
            if (pipelineName != string.Empty && args != null)
            {
                //get the processors for the pipeline if they exist
                GetProcessors(pipelineName, filePath);
                GetConnectionString(connectionStringName, filePath);
                //add the args object to the private prop
                _args = args;
            }
            else
                this.WasError = true;
        }
        public object Run()
        {
            if (!this.WasError)
            {
                Object[] obj = _args;
                //no error

                //loop through and execute the values
                foreach (var processor in _processors)
                {
                    //invoke processor
                    string className = GetClassName(processor);
                    string assemblyName = GetAssemblyName(processor);
                    var classInfo = this.GetClassReference(assemblyName, className);
                    var retVal = this.InvokeMethod(assemblyName, className, "Process", obj);
                    if (retVal != null)
                    {
                        var results = (PipelineArgs)retVal;
                        if (results.Abort)
                        {
                            //break out and update arg
                            obj[0] = retVal;
                            break;
                        }
                        else
                        {
                            //update the arg
                            obj[0] = retVal;
                        }
                    }
                    else
                    {
                        //there was an error

                        //break out
                    }
                    //update args
                }
                return obj;
            }
            else
                return null;
        }
        //TODO: current issue is that class name is used, which causes a conflict if there are two classes with the same name. need to change to use the full namespace. temp solution is to ensure that each class name is uniqe even outside of the namespace 
        public DynClassInfo GetClassReference(string AssemblyName, string ClassName)
        {
            if (ClassReferences.ContainsKey(ClassName) == false)
            {
                //need to sepecify what the assembly is
                var currentassembly = Assembly.LoadWithPartialName(AssemblyName);
                var path = currentassembly.Location;

                Assembly assembly;
                if (AssemblyReferences.ContainsKey(AssemblyName) == false)
                {
                    AssemblyReferences.Add(AssemblyName, assembly = Assembly.LoadFrom(path));
                }
                else
                    assembly = (Assembly)AssemblyReferences[AssemblyName];

                // Walk through each type in the assembly
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass == true)
                    {
                        // doing it this way means that you don't have
                        // to specify the full namespace and class (just the class)
                        if (type.FullName.EndsWith("." + ClassName))
                        {
                            DynClassInfo ci = new DynClassInfo(type, Activator.CreateInstance(AssemblyName, type.FullName));
                            ClassReferences.Add(ClassName, ci);
                            return (ci);
                        }
                    }
                }
                throw (new System.Exception("could not instantiate class"));
            }
            return ((DynClassInfo)ClassReferences[ClassName]);
        }

        private Object InvokeMethod(DynClassInfo ci, string MethodName, Object[] args)
        {
            foreach(var meth in ci.type.GetMethods())
            {
                if(meth.Name == "Process")
                {
                    Object Result = meth.Invoke(ci.ClassObject, args);
                    return (Result);
                }
            }

            return null;
            //ci.type.InvokeMember(MethodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, ci.ClassObject, args);
            
        }

        public Object InvokeMethod(string AssemblyName, string ClassName, string MethodName, Object[] args)
        {
            DynClassInfo ci = GetClassReference(AssemblyName, ClassName);
            return (InvokeMethod(ci, MethodName, args));
        }











        private string GetClassName(string value)
        {
            string retVal = "";

            if (value != string.Empty)
            {
                string[] vals = value.Split(',');
                retVal = vals[0].Split('.').Last();
            }

            return retVal;
        }
        private string GetAssemblyName(string value)
        {
            string retVal = "";

            if (value != string.Empty)
            {
                string[] vals = value.Split(',');
                retVal = vals[1].Trim();
            }

            return retVal;
        }

        //private Object InvokeMethodSlow(string AssemblyName, string ClassName, string MethodName, Object[] args)
        //{
        //    // load the assemly
        //    Assembly assembly = Assembly.LoadFrom(AssemblyName);

        //    // Walk through each type in the assembly looking for our class
        //    foreach (Type type in assembly.GetTypes())
        //    {
        //        if (type.IsClass == true)
        //        {
        //            if (type.FullName.EndsWith("." + ClassName))
        //            {
        //                // create an instance of the object
        //                object ClassObj = Activator.CreateInstance(type);

        //                // Dynamically Invoke the method
        //                object Result = type.InvokeMember(MethodName,
        //                  BindingFlags.Default | BindingFlags.InvokeMethod,
        //                       null,
        //                       ClassObj,
        //                       args);
        //                return (Result);
        //            }
        //        }
        //    }
        //    throw (new System.Exception("could not invoke method"));
        //}
        private void GetProcessors(string pipelineName, string filePath)
        {
            List<string> retVal = new List<string>();

            string rootPath = filePath;
            var xmlConfig = XDocument.Load(rootPath);
            IEnumerable<XElement> xmlLst = xmlConfig.Descendants("Pipeline");
            if (xmlLst.Any())
            {
                var trgPipeline = xmlLst.Where(n => n.Attribute("name").Value == pipelineName);
                if (trgPipeline.Any())
                {
                    var processors = trgPipeline.Descendants();
                    if (processors.Any())
                    {
                        foreach (var p in processors)
                        {
                            retVal.Add(p.Attribute("value").Value);
                        }
                    }
                    this._processors = retVal;
                    this.WasError = false;
                }
                else
                    this.WasError = true;
            }
        }
        private void GetConnectionString(string connectionStringName, string filePath)
        {
            string retVal = String.Empty;

            string rootPath = filePath;
            var xmlConfig = XDocument.Load(rootPath);
            IEnumerable<XElement> xmlLst = xmlConfig.Descendants("connection");
            if (xmlLst.Any())
            {
                var trgPipeline = xmlLst.Where(n => n.Attribute("name").Value == connectionStringName);
                if (trgPipeline.Any())
                {
                    var processors = trgPipeline.Descendants();
                    if (processors.Any())
                    {
                        foreach (var p in processors)
                        {
                            retVal = processors.First().Attribute("connectionString").Value;
                        }
                    }
                    this._connectionstring = retVal;
                    this.WasError = false;
                }
                else
                    this.WasError = true;
            }
        }
    }
}
