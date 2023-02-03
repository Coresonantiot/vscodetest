using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HexTest.WebUI.ServiceResponse
{
    public enum ResponceCodes
    {
        SUCCESS = 200, 
        FAILURE = 400,
        INTERNAL_ERROR = 500,
        PROJECT_NOT_FOUND = 504,
        PROJECT_SOLUTION_FOLDER_AND_FILES_NOT_FOUND = 505,
        JSON_VALIDATION_FAILED = 901,
        INVALID_REQUEST_OBJECT = 902,
        METADATA_MISSING = 601,
        METADATA_ACCOUNTID_MISSING = 602,
        METADATA_PROJECTID_MISSING = 603,
        ENTITIES_DATA_MISSING = 701,
        INVALID_ENTITIES_DATA = 702,
        FILE_NOT_FOUND = 404,
        DUPLICATE_FIELD_NAMES = 703,
        INVALID_RELATIONSHIP_ENTITY = 710,
        INVALID_RELATIONSHIP_ENTITY_FIELD = 711,
    }
}