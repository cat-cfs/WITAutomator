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

*Example*
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
Specifies CBM-CFS3 Standard Import tool options. Some of the options **do not** need to be edited for use with the WIT

**Items that _do not_ need to be edited**
  * output_path - specifies the output_path, however the application will overwrite the value 
  * import_config - all items in this section are constant for the WITAutomator, and do not need to be changed
  
**Items that _do_ need to be edited**  
  * mapping_config
    * default_spuid defines a key that links to default CBM-CFS3 parameters. Change this to the appropriate value for your province, ecological boundary combination.  See the ArchiveIndex table tblSPUDefault, tblAdminBoundaryDefault, tblEcoBoundaryDefault
  * disturbance_type_mapping - for each disturbance type defined in the woodstock data, a mapping to a CBM-CFS3 default disturbance type must exist.  The names of the CBM-CFS3 disturbance types is defined in the archive index table tblDisturbanceTypeDefault. The example shows mapping for 2 disturbance types:
    1. Woodstock disturbance type: *"Wildfire"* maps to CBM-CFS3 disturbance type *"Wildfire"*
    2. Woodstock disturbance type: *"_DEATH"* maps to CBM-CFS3 disturbance type *"Wildfire"*
  * species_mapping - for each species name in the Woodstock _species theme_ an entry must exist in this section that maps to a CBM-CFS3 default species name. In the example the Woodstock theme value _"035  Black Spruce Forest"_ is mapped to the CBM-CFS3 default species name _"Spruce"_.  The complete definition of the CBM-CFS3 Species name is defined in the Archive index table tblSpeciesTypeDefault.
    
  
*Example*
```json
{
  "output_path": "",
  "import_config": {
    "path": "",
    "ageclass_table_name": "SIT_AgeClasses",
    "classifiers_table_name": "SIT_Classifiers",
    "disturbance_events_table_name": "SIT_Events",
    "disturbance_types_table_name": "SIT_DisturbanceTypes",
    "inventory_table_name": "SIT_Inventory",
    "transition_rules_table_name": "SIT_Transitions",
    "yield_table_name": "SIT_Yields"
  },
  "mapping_config": {
    "spatial_units": {
      "mapping_mode": "SingleDefaultSpatialUnit",
      "default_spuid": 42
    },
    "disturbance_types": {
      "disturbance_type_mapping": [
        {
          "user_dist_type": "Wildfire",
          "default_dist_type": "Wildfire"
        },
        {
          "user_dist_type": "_DEATH",
          "default_dist_type": "Wildfire"
        },
      ]
    },
    "species": {
      "species_classifier": "1 Forest Management Unit",
      "species_mapping": [
        {
          "user_species": "035  Black Spruce Forest",
          "default_species": "Spruce"
        },
      ]
    },
    "nonforest": null
  }
}
```
