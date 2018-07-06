1. I used the full 2 hours
2. I would probably put in more testing
3. Yes I did. I used the ASP.Net core's dependency injection though, as opposed to Unity. I used this because I was planing on writing tests but I ran out of time
4. Adding logging would almost certainly be my first approach. Depending on the issue and the set up, I may attach the debugger to the process running in prob. But in most scenarios this wouldn't be appropriate 
5. I would probably rewrite it in JSON. I would also use RESTful standards and conventions. i.e. I would remove /list and /get off the end of endpoints and just use http verbs instead
6. EF7 and Newtonsoft. I love the new lightweight way of doing things in EF7 and I love Newtonsoft because I think it's one of the best open source libraries in dotnet 
7. Probably dotnet core. I love the way it's cross platform and I'm a huge fan of the new architecture.
8. 

```json
{
 firstName: 'Thomas',
 lastName: 'Horrobin',
 age: 27,
 siblings: [
     {
        firstName: 'Ella',
        lastName: 'Horrobin',
        age: 25,
     }
 ],
 citiesLivedIn: [
     {
         name: 'Auckland',
         population: 1200000
     },
     {
         name: 'Wellington',
         population: 300000
     },
     {
         name: 'London',
         population: 8500000
     },
 ]
}
```