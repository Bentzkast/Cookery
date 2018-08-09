angular - spa

services

3rd party library

-   alertify
-   auth0jwt 2.0.0
-   ngx boostrap 3.0.01
-   bootswatch theme
-   ngx gallery

dotnet - api

error handling
slap header with response
auto mapper

user development seed

```
[
  '{{repeat(10)}}',
  {
    Username: '{{firstName()}}',
    Password: 'password',
    Picture: 'http://placehold.it/32x32',
    About: '{{lorem(1, "sentences")}}',
    Registered: '{{date(new Date(2014, 0, 1), new Date(), "YYYY-MM-ddThh:mm:ss Z")}}',
    Recipes: [
            '{{repeat(1,4)}}',
    {

      Name: '{{lorem(2,"words")}}',
      Description: '{{lorem(1, "sentences")}}',
      Ingredients : '{{lorem(6,"words") }}',
      Instruction :'{{lorem(1, "sentences")}}',
      PictureUrl: 'http://placehold.it/32x32',
      DateAdded: '{{date(new Date(2014, 0, 1), new Date(), "YYYY-MM-ddThh:mm:ss Z")}}'
  	}
    ]
  }
]
```
