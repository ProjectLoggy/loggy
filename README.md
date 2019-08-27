## Loggy

Loggy aims to be the one stop solution for all your personal life tracking and logging needs. Whether it be logging your weight, expenses, sleep or food intake, Loggy's seamless integration between platforms and channels will ensure you always are able to track your activity at a moments notice. 

## Getting Started

```git clone https://github.com/ProjectLoggy/loggy.git ```

## Architecture

* [Architecture docs](https://github.com/ProjectLoggy/loggy/blob/master/doc/architecture.md)

### Prerequisites (local environment)

* Visual Studio 2017+ or Jetbrains Rider
* Git.
* Docker for Desktop with Kubernetes enabled.
 
### Installing

* Pull source code from the repo.
* Build docker images.
* Deploy to local Docker-Kubernetes cluster to test.

## Contributing

We're still laying the foundations. Check here back soon!

## Built With

* [.NET CORE 2.2](https://www.microsoft.com/net/download) - Server-side
  * [xUnit](https://xunit.net/) - Back end unit tests.
* [GraphQL](https://graphql.org/) using [GraphQL-dotnet](https://github.com/graphql-dotnet/graphql-dotnet) - API Handler
* [React](https://reactjs.org/) - Front end
  * [Jasmine BDD](https://jasmine.github.io/index.html) - Front end unit tests.
  * [TypeScript](https://www.typescriptlang.org/) - Type checking.
  * [Redux](https://redux.js.org/) - State management.
  * [Webpack](https://webpack.js.org/) - Bundling.
  * [Babel](https://babeljs.io/) - Transpiling.
* [Kubernetes](https://kubernetes.io/) - Orchestration
  * [Kibana](https://www.elastic.co/products/kibana) and Elastic Stack for cluster monitoring.
* [MongoDb](https://www.mongodb.com/) - Data storage
* [Katalon](https://www.katalon.com/) - Integration testing.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](Coming soon...)

## CI/CD

PR's will automatically trigger a build on [Travis](https://travis-ci.com/ProjectLoggy/loggy). PR's should not be merged unless the build is successful. 
Code quality analysis is done using [Sonar Qube](https://sonarcloud.io/organizations/projectloggy/projects)

## Running the tests

Coming soon...

## Deployment

Coming soon...

## Authors

* **Willem Odendaal** - [WillemO](https://github.com/willemodendaal)
* **Ryan McCartney** - [Ryan](https://github.com/RJMccartney)
* **Jean-Paul Thorne** - [JP](https://github.com/JPThorne)

See also the list of [contributors](https://github.com/ProjectLoggy/loggy/graphs/contributors) who participated in this project.

## License

This project is licensed under the GPL License - see the [LICENSE.md](LICENSE.md) file for details.
