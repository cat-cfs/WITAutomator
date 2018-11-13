# WITAutomator
Application built on top of Standard Import tool and Woodstock import tool to automate import straight from DBF format

[Download link](https://github.com/cat-cfs/WITAutomator/releases)

## Running From the Command line

 
```<path_to_dir>\WITAutomator.exe -c config.json -s sit_config_template.json```

### Arguments

#### -c configuration file in json format
Specifies the basic program options

  * rounding_option - one of MidPointRoundedUp, MidPointRoundedDown, SplitByPeriodWidth
  * dbf_dir - path to a directory containing the woodstock dbf files with default names
    * actions.dbf
    * areas.dbf
    * yields.dbf
    * themes.dbf
    * trans.dbf
    * schedule.dbf
  * cbm_project_output_path - path of a CBM-CFS3 project database to be created by this application
  * woodstock_accdb_path - path of the intermediate Standard Import tool input database created by this application
  * species_theme_name - name of the species classifier as defined in the woodstock dbf files

Example
```json
{
    "rounding_option": "MidPointRoundedDown",
    "dbf_dir": "C:\\dev\\WITAutomator\\WITAutomatorTest",
    "cbm_project_output_path": "C:\\Program Files (x86)\\Operational-Scale CBM-CFS3\\Projects\\WITAutomatorTest_CBMProject.mdb",
    "woodstock_accdb_path": "C:\\Program Files (x86)\\Operational-Scale CBM-CFS3\\Projects\\WITAutomatorTest_WoodstockDB.accdb",
    "species_theme_name": "1 Forest Management Unit"
}
```
#### -s standard import tool configuration template
