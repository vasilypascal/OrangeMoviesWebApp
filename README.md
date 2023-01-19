# OrangeMoviesWebApp
A web application for researching the best movies of all time

In order to use the web application you must have MS Sql Server installed locally.
In order to apply EF Core migrations open the OrangeMoviesWebApp.sln -> Package Manager Console -> run next command:

Update-Database -Context OrangeMoviesDbContext

Now you can enjoy Orange Movies Web Application  :)

--------------------------------------------------------

Task points implemented:

- Created MVP for Orange Movies Web Application:
- Added ApiHttpClient for working with third-party Apis
- Added Sorting
- Added Grouping by genres by clicking on any of them
- Added Pagination
- Added "Favourite Movies" functionality and View
- Added "View Movie Details" functionality and View
- Attached bootstrap and manually configured all styles
- Added one Unit Test for demonstration purpose

Tasks left to do:

- Refactor mapping functionality
- Add ViewModels
- Add logging
- Cover all left methods with unit tests
- Implement complex pagination
- Implement complex grouping
- Adjust styling and add comment descriptions