# IoT_Assignments
 
# Backend
This was the first time I wrote C# specifically.
-------------------------------------------
This is the folder with the projects for the Backend Assignment
IoT_Backend_Assignment: Is the DLL that when built creates the .dll file we will use in the other project to call the IpStack API
WebApi: This is the project that contains part 2 and 3 of the assignent. Contains the classes and methods for the custom API, cache and database handling.

APIs:
get "http://localhost:5137/WebApi/GetIpDetails/-ip-" where -ip- we put the ip we want the details for
post "http://localhost:5137/WebApi/update" where in the body of the request we put our field to be changed, the new value and the ip that is for ie:
{
  "IP": "127.0.0.1",
  "field": "Country",
  "value": "Italy"
}
get "http://localhost:5137/WebApi/progress/-batch-id-" where -batch-id- is the id of the batch we want to learn its progress


# Frontend
-------------------------------------------
This is the folder with the projects for the Frontend Assignment
