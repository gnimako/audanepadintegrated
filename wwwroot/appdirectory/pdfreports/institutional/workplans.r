


rm(list=ls(all=TRUE)) 
setwd("~/audanepadintegrated/institutional")

if(!require(pacman))install.packages("pacman")
library(ggplot2)

pacman::p_load('dplyr', 'tidyr', 'gapminder',
               'ggplot2',  'ggalt',
               'forcats', 'R.utils', 'png', 
               'grid', 'ggpubr', 'scales',
               'bbplot')

devtools::install_github('bbc/bbplot')

line_df <- gapminder %>%
  filter(country == "Malawi") 




tiff("test.png", units="in", width=8, height=5, res=300)

line <- ggplot(line_df, aes(x = year, y = lifeExp)) +
  geom_line(colour = "#1380A1", size = 1) +
  geom_hline(yintercept = 0, size = 1, colour="#333333") +
  bbc_style() +
  labs(title="Living longer",
       subtitle = "Life expectancy in China 1952-2007")


line
dev.off()