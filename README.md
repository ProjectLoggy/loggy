## Loggy

Loggy aims to be the one stop solution for all your personal life tracking and logging needs. Whether it be logging your weight, expenses, sleep or food intake, Loggy's seamless integration between platforms and channels will ensure you always are able to track your activity at a moments notice. 

## Getting Started

```git clone https://github.com/ProjectLoggy/loggy.git ```

## Architecture

* [Architecture docs](https://github.com/ProjectLoggy/loggy/blob/master/doc/architecture.md)

### Prerequisites

* Visual Studio 2017 - Enterprise or Community Edition.
* Git
* [Minikube](https://kubernetes.io/docs/setup/minikube/) - Simple Kubernetes cluster, to debug locally.
  * See [Minikube Windows 10 Debugging Tips](https://github.com/ProjectLoggy/loggy/blob/master/doc/minikube%20windows%2010%20debugging%20tips.md) if you have trouble running Minikube.
 
### Installing

* Pull source code from the repo.
* Build docker images.
* Update local Kubernetes deployments by deploying to Minikube.

## Running the tests

Coming soon...

## Deployment

Coming soon...

## Built With

* [.NET CORE 2.2](https://www.microsoft.com/net/download) - BackEnd language
  * MSTest - BackEnd unit tests.
* [GraphQL](https://graphql.org/) using [GraphQL-dotnet](https://github.com/graphql-dotnet/graphql-dotnet) - API Handler
* [React](https://reactjs.org/) - FrontEnd
  * [Jasmine BDD](https://jasmine.github.io/index.html) - FrontEnd unit tests.
  * [TypeScript](https://www.typescriptlang.org/) - Type checking.
  * [Redux](https://redux.js.org/) - State management.
  * [Webpack](https://webpack.js.org/) - Bundling.
  * [Babel](https://babeljs.io/) - Transpiling.
* [Kubernetes](https://kubernetes.io/) - Orchestration
* [MongoDb](https://www.mongodb.com/) - Data storage
* [Katalon](https://www.katalon.com/) - Integration testing.

## Contributing

Clone

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](Coming soon...)

## CI/CD

PR's will automatically trigger a build on [Travis](https://travis-ci.com/ProjectLoggy/loggy). PR's should not be merged unless the build is successful. 
Code quality analysis is done using [Sonar Qube](https://sonarcloud.io/organizations/projectloggy/projects)

## Authors

* **Willem Odendaal** - *Idea Wizard and Repo Creator* - [WillemO](https://github.com/willemodendaal)
* **Ryan McCartney** - *The next Zuckerberg and Readme designer* - [Ryan](https://github.com/RJMccartney)
* **Jean-Paul Thorne** - *Who came up with these titles???* - [JP](https://github.com/JPThorne)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the GPL License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Shoutout to Goku
* Inspiration from JP Thorne
* Big thanks for Tim-Berners Lee for making the web all possible
