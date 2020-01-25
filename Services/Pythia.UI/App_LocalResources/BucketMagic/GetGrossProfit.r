library(dplyr)
library(tidyr)

record$cost <- record$Hours * record$Pay.Rate
record$totalCost <- record$Hours * record$Complete.Charge
record$profit <- record$totalCost - record$cost

