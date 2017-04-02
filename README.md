# Repository
Generic repository to get domain objects from any of the sources (Database, Entity framework, File system and etc.,.)

Repository patteren is one of the nicest patterns of all time and here is the generic repository pattern template. By making use of this template one can avoid lot of boilerplate code.

## Goal of this template
As I mentione earlier, goal of this template is to reduce lot of boilerplate code and business access layer will never bother about underlying data source. Underlying datasource could be anything Database (ADO.Net), Entity framework, API, File system, Web service and etc.,.

Business layer just see eveything as objects which comes out of repository.
