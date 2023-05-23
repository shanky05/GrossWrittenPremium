# GrossWrittenPremium
Open the server.sln file.
Run the application from VS.
Open Postman start making requests.

Sample request(Http Post) : https://localhost:9091/server/api/gwp/avg
Request Body : {
  "country": "ae",
  "lineOfBusiness": [
    "transport",
    "freight"
  ]
}

Sample Response :
 [
    {
        "transport": 139212683.74999997
    },
    {
        "freight": 130598194.275
    }
]
