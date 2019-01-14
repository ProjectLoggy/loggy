## Loggy.Api

### Sample queries

Query: 
     
	 {
       subQuery {
         subQueryName
       }
     }

Response:

	{
	  "data": {
		"subQuery": {
		  "subQueryName": "Some string value"
		}
	  }
	}