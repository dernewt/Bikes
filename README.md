# Bikes
Code is to help someone learn C# in order to work through https://github.com/solita/dev-academy-2022-fall-exercise

# Bikes.API 
a GraphQl api driven off csv files. You'll have to supply them via data/.

Sample Query:
```
{
  allBikeRoutes(first: 100
  where: { distance: {meters: {gt: 40000}}}
  ) {
    pageInfo {
      hasNextPage
    }
    edges {
      cursor
      node {
        isTooShort
        departure
        return
        from {
          id
          name
          address
          city
          operator
          capacity
          x
          y
        }
        to {
          id
          name
          address
          city
          operator
          capacity
          x
          y
        }
        distance
        duration
      }
    }
  }
}

```

# Bikes.Core
# Bikes.Test
