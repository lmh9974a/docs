# What's new

{PANEL:3.0.30143 - 2016/06/01}

### Server

- `[Voron]` Fixed access violation exception.
- `[Voron]` Fixed an edge case in page splitter.
- `[FileSystem]` Fixed issues in files replication.
- `[Indexes]` Better handling of `OperationCanceledException`.
- `[Prefetcher]` Fixed too frequently calls to `MaybeAddFutureBatch`.
- `[PeriodicExport]` Fixed an export fail when initial backup is more than 64MB.
- `[PeriodicExport]` Better error handling.

<hr />

### Client

- Fixed async query that uses ContainsAny or In.
- Fixed parsing a double value from object.
- `[Subscrition]` Better error handling.
- `[Subscrition]` Notify the server that subscriptions can be reused when the store is disposed.
- Fixed using `ShardedDocumentStore` with a query and a transformer.

<hr />

### Smuggler

- Fixed an identities that was imported which started with `Raven/`.

<hr />

### Studio

- `[SqlReplication]` Stats are not available for not admin user.
- Fixed edit document page start page in `Doc {start} of {total}`.

{PANEL/}

{PANEL:3.0.30115 - 2016/04/10}

### Server

- **[Major]** `[Prefetching]` Fixed memory leak that could lead into slowness of the server under heavy load impacting indexing and replication mechanisms,
- **[Major]** `[Indexing]` Fixed issue when new indexes could stuck at 32768 entries under certain conditions when precomputed batch flow was executed,
- `[JavaScript]` Fixed float conversion
- Added memory statistics thread state to stats (`IsMemoryStatisticThreadRuning`)

<hr />

### Client

- `AlwaysWaitForNonStaleResultsAsOfLastWrite` convention marked as obsolete
- Fixed concurrency errors when retrieving identity values concurrently by `DatabaseCommands.NextIdentityFor`
- Fixed JSON parsing of data using base64 format

<hr />

### Studio

- Fixed import with credentials usage
- Fixed replicate all indexes and transformers options
- Fixed Etag verification when changing an identifier of an existing document

{PANEL/}

{PANEL:3.0.30100 - 2016/03/17}

### Server

- `[Indexing]` Fixed handling of indexes which were disabled,
- `[Indexing]` Added support for nullable types to facets,
- `[Indexing]` Fixed updates of side-by-side indexes,
- `[Indexing]` Fixed index staleness detection,
- `[Indexing]` Fixed an issue where we wouldn't treat JsonPropertyAttribute correctly during the indexing,
- `[Indexing]` Added support for custom type arrays in an index definition,
- `[Prefetching]` Adjustments to document prefetching mechanism,
- `[Esent]` Fixed Esent storage schema update (4.8 to 5.0),
- `[Voron]` Fixed handling of overflow pages
- `[JavaScript]` Fixed math random init in Jint,
- `[Replication]` Fixed "Resolve to latest" conflict resolution strategy,
- `[Configuration]` Exposed `Raven/Voron/SkipConsistencyChecks` setting,
- `[Configuration]` Added `Raven/MaxPrecomputedBatchSizeForNewIndex` setting,
- Fixed document caching mechanism,
- Fixed validation of OEM/ISV licensed affecting the startup performance,
- Fixed UDP port leak in licensing component,
- Fixed debug info generation,
- Fixed UniqueConstraintsPutTrigger, which shallowed a snapshot of a document,
- Added `debug/sl0w-lists-breakd0wn` debug endpoint exposing internal lists breakdown,
- Fixed timing of dynamic queries,

<hr />

### Client

- Fixed querying with transformer usage - respecting query type instead of transformer one,
- Fixed `session.Advanced.Lazily.Load()` and `session.Include().Load()` methods against passing duplicate identifiers,
- Fixed includes in a sharded session,
- Fixed loads in a sharded session (when array of identifiers specified),
- Fixed insertion of multiple indexes with given priorities,
- Fixed internals of UniqueConstraint bundle,
- Fixed `AllowMultipleIndexEntriesForSameDocumentToResultTransformer` flag application,
- Added extension methods to work with authorization bundle (`Raven.Client.Authorization` namespace),
- Fixed filtering of ignored headers,
- Optimized memory usage when streaming documents with missing properties according to a given type,
- Optimized usage of HttpClient cache,
- Fixed reconnection issue in Changes API

<hr />

### Studio

- Fixed traffic watch for file systems,
- Fixed documents visibility on the patching page,
- Fixed vertical scrolling bar on the collections and document view,
- Fixed import to CSV to preserve column ordering, skipping and document identifier if present,
- Fixed info view of currently running tasks,
- Fixed escaping of queries with contains `:` character

<hr />

### Smuggler
- Fixed issue that an export file didn't include documents created during the export operation,
- Fixed export of file systems,
- Added `--batch-size` option for smuggling file systems,
- Fixed import operation for large attachments,
- Fixed smuggler "between" option to ensure documents added during the operation are transferred as well

{PANEL/}

{PANEL:3.0.30037 - 2016/01/09}

### Server

- `[DTC]` Fixed NonAuthorativeInformation detection,
- Added `admin/generate-oauth-certificate` endpoint,
- Exports will now include documents created during the export time,
- Fixed licensing timer leaks,
- Minor fixes and tweaks,
- Added a mechanism preventing from opening a resource with a different storage type than is defined in configuration,
- Added a mechanism preventing from creating a different resource type than is defined in data directory,
- `[Scripted Index Results]` will work correctly if there are multiple loads and puts of the same document in same batch,
- `[JavaScript]` decreased max recursion from 1024 to 128,
- `[Replication]` added `LastReplicatedAttachmentEtag` to the replication statistics,
- `[Patching]` Inc operation will now assume that the value is Int64, not Int32,
- Better mechanism preventing index corruption after server crash

<hr />

### Client API

- **support for DNX Core 5.0** (only unstable builds greater than 30011 due to NuGet policies),
- Streams now contain full document metadata,
- Added `SetResultTransformer` overload to `IDocumentQuery` and `IAsyncDocumentQuery`,
- Query `DurationMilliseconds` is set to -1 when response comes from cache

<hr />

### Studio

- Fixed FileSystem import,
- Studio should not allow to 'save' locked index or should indicate after pressing save that the index is locked and changes will not be saved,
- Minor fixes and tweaks

<hr />

### FileSystem

- Failure to start FileSystem should result in 503, not 500 status code,
- Fixed issues with recreating IndexSearcher during index reset, which could result in a failure to access index files,
- Fixed FileSystem exports,
- Fixed issue with streaming, now streams will exclude internal files (tombstones, deleted, synchronized),
- Stability improvements

<hr />

### StorageExporter

- Added `SkipConsistencyCheck` option

<hr />

### Smuggler

- Better export timeout handling,
- Enhanced server version discovery

{PANEL/}

{PANEL:3.0.30000 - 2015/11/19}

- **[Breaking Change]** Changed the build number in the RavenDB version (3.0.**30000**)

### Server

- `[Prefetching]` Fixed performance issues,
- `[Indexing]` Fixed an issue with accessing index files (System.ObjectDisposedException: Cannot access '_[xxx].fdt' because the index input has been disposed or System.IO.FileNotFoundException: Can not load ICSharpCode.SharpZipLib.dll),
- `[Indexing]` Fixed reduction phase which skipped docs when first time it was performed in a single step but later it was processed as a multi step operation,
- `[Indexing]` Fixed race condition in Lucene.net spatial contrib,
- `[DTC]` Fixed an issue with deletes performed in multiple concurrent threads (while in a distributed transaction) were not being replicated,
- `[Scripted Index Results]` Fixed missing execution of index update triggers when removing from map-reduce index using RemoveFromIndexTask,
- `[Scripted Index Results]` Fixed conversion of null string properties,
- `[SQL Replication]` Fixed bug when comparing with `null` in a sql replication script,
- `[Configuration]` Added `Raven/Tenants/MaxConcurrentResourceLoads` and `Raven/Tenants/ConcurrentResourceLoadTimeout` settings which limit concurrent load of resources (databases, filesystems, etc)

<hr />

### Client API

- Added support for transactional sessions with DTC under async sessions,
- Fixed an issue with unbounded results API which returned up to 128 documents when doing spatial query using Customize(),
- Enabled compression for more requests to shrink the amount of data transferred through the network,
- Added `InMemoryDocumentSessionOperations.UnregisterMissing` and invoke it before loading `ConstraintDocument` in bundle,
- Added new overload of `SetResultTransformer` to `IDocumentQuery` that allows strong-typing of the transformed result independently of the type of the index entries.

<hr />

### Data Subscriptions

- Changed the approach of retrieving and processing documents to avoid connection breaks caused by consuming incoming data too slowly,
- Fixed issues related to opening a subscription depending on a specified strategy,
- Fixed a timeout handling in subscriptions if all documents are filtered out

<hr />

### File systems

- Fixed OutOfMemoryException when uploading large files or synchronizing between servers,
- Fixed an issue that a file were accessible even though its upload has been aborted,
- Fixed file uploads with Windows Auth enabled 

<hr />

### Smuggler

- Fixed the import of dump files containing `Raven/Subscription/...` identities used by Data Subscrptions,
- Added support for transform / filter scripts on database export.

<hr />

### Studio

- Added transform script validation for import/export operations. Fixing help message and outdated links,
- Fixed Patch by index - query not filtering matching documents,
- Fixed acquisition of the debug info package if the server machine has .NET installed in version 4.5.2 or 4.6,
- Faster transitions,
- Fixed race condition between loading the studio version and generating help link,
- Fixed Patch page - when selecting a collection the documents are overlapping the Before Patch and After Patch,
- Fixed Indexes page - show if index is map reduce

{PANEL/}

{PANEL:3.0.3800 - 2015/09/21}

### Server

- Improved formatted index generation with better error handling,
- Fixed issue with single OAuth tokens caching,
- Larger batches are now handled better by Map-Reduce indexes,
- Added support for HEAD request for streams,
- Fixed `ArgumentOutOfRangeException` that could occur during reading from Lucene index

### File systems

- Better handling of larger files with longer names

<hr />

### Client API

- Fixed issue with saving documents to proper database in ShardedBulkInsert operation,
- Fixed issues with index generation,
- IndexCreation now takes into account conventions,
- Added the option to specify timeout of a subscriptions pull request

<hr />

### Studio

- Fixed replication topology graph
- Fixed replication settings page

{PANEL/}

{PANEL:3.0.3785 - 2015/08/31}

### Server

- `[Voron]` increased scratch buffer size to 6144 MB and added a threshold after which indexing/reducing batch sizes will start decreasing,
- `[Voron]` map/reduce optimizations. We have done major work to optimize how RavenDB uses map/reduce on Voron. As a result, map/reduce performance on Voron has improved tremendously. However, this require a migration step during the first startup,
- `[Voron]` optimized recovery code heavily to support slow I/O systems on large databases,
- Changed shutdown sequence - each database / file system waits up to 3 seconds to complete existing requests before they get aborted,
- Fixed creation of future batches (prefetching mechanism),
- Changed index priority does not force index reset,
- Handled failures of index resets,
- Fixed loading of startup tasks when hosted in IIS,
- Fixed `Lucene.Net` to properly dispose files in out of disk space scenario,
- Fixed `Lucene.Net` memory allocation on queries. We have drastically reduced the amount of memory that is allocated per query, and improved the performance of queries substantially
- Better handling of buffer allocations in websockets, reduces memory fragmentation,
- Better handling of Take() / Skip() inside an index
- Many small perf optimizations, memory allocations reductions, object pooling, etc. Drastic reduction in memory allocations on common code paths,
- Allow only a single index to use the fast precomputation optimization at a time (reduce memory usage if multiple medium sized indexes are changed concurrently),
- Re-implemented memory statistics checks using native calls to avoid expensive allocations,
- Provide more detailed information when an index is corrupted,
- Adding endpoint for stopping/starting just reduce work. More [here](../../http/client-api/commands/how-to/start-stop-reducing),
- Less aggressive changes to the batch size at scale, being more cautious gives us a bit slower perf but more stable system under load,
- Fixed side-by-side index updates,
- Allowed to update side-by-side index when it is still running,
- Fixed .NET 4.6 compilation errors,
- Fixed an NRE when the index definition was removed forcibly when using dynamic queries,
- Fixed error handling during disposal causing an exception to escape thread boundary and crashing,
- Fixed FIPS licensing issue on embedded databases,
- Fixed a finalizer usage bug causing us to try to read from a closed handle,
- Prevent corrupted index warning when creating a map-reduce index and indexing is disabled,
- Preventing code from trying to use disposed internal transactions,
- Properly dispose of timer instance when shutting down a database using expiration bundle,
- Prevent an error loading ICSharpCode.NRefactory from killing RavenDB client startup

#### [Configuration](../server/configuration/configuration-options)

- Increased `Raven/Voron/MaxScratchBufferSize` from 1024 to 6144. More [here](../server/configuration/configuration-options#voron-settings),
- Added `Raven/Voron/ScratchBufferSizeNotificationThreshold`. More [here](../server/configuration/configuration-options#voron-settings),
- Added `Raven/MaxClauseCount`. More [here](../server/configuration/configuration-options#index-settings),
- Added `Raven/Indexing/DisableIndexingFreeSpaceThreshold`. More [here](../server/configuration/configuration-options#index-settings)

### File systems

- Fixed file synchronization mechanism,
- Fixed files handling with `#` character in name

### Bundles

- `[Replication]` Fixed request buffering issues	

<hr />

### Client API

- Added `AbstractScriptedIndexCreationTask`. More [here](../server/bundles/scripted-index-results#example-ii---abstractscriptedindexcreationtask),
- Added `SetTransformerLock` command. More [here](../client-api/commands/transformers/how-to/change-transformer-lock-mode),
- Added `PutIndexes` command. More [here](../client-api/commands/indexes/put#putindexes),
- Added `Include<TResult>(Expression<Func<T, object>> path)` to async session,
- Implemented `GetMetadataForAsync<T>(T instance)` in advanced options of async session of `ShardedDocumentStore`,
- `WithinRadiusOf` marked as obsolete in spatial querying because of the parameter order inconsistency. `WithinRadius` is designated to be used instead. More [here](../indexes/querying/spatial),
- Added `StartEtag` to `SubscriptionCriteria`. More [here](../client-api/data-subscriptions/how-to-create-data-subscription),
- Added opening strategies to data subscriptions. More [here](../client-api/data-subscriptions/how-to-open-data-subscription),
- Added `BeforeAcknowledgment` and `AfterAcknowledgment` events to data subscription. More [here](../client-api/data-subscriptions/events),
- Added "Query parsing" measure for `ShowTimings` query customization. More [here](../client-api/session/querying/how-to-customize-query#showtimings),
- Added `TransformerLockMode`. More [here](../client-api/commands/transformers/how-to/change-transformer-lock-mode),
- Added `Load` overload with transformer to `ILoaderWithInclude`. More [here](../client-api/session/loading-entities#example-iii-1),
- `IndexCreation.CreateIndexes` creates indexes in a single request,
- `DocumentStore.SideBySideExecuteIndexes` and `DocumentStore.SideBySideExecuteIndexesAsync` creates side by side indexes in a single request,
- Implemented bulk inserts for `ShardedDocumentStore`,
- Optimized memory allocation and better performance in [profiling](../client-api/how-to/enable-profiling),
- Fixed implementations of sync methods to avoid hangs,
- Fixed caching of `HttpClient`,
- Extended IEnumerable implementation of `DynamicList` - more available extensions in an index definition

<hr />

### Studio

- Environment based studio themes. More [here](../studio/management/studio-config),
- Added `Status -> Debug -> Currently indexing`,
- Added IO Test. More [here](../studio/management/io-test),
- Added License server information. More [here](../studio/management/license-information),
- Fixed authentication by API keys,
- Fixed inconsistency bug in Query intellisense,
- Exposed option StoreAllFields (Edit index view),
- Support for pre 3.0 versioning documents

<hr />

### Installer

- Added options to check port availability and revoke URL reservation according to provided port number when installing on IIS,
- Added support for IIS 10 detection on Windows 10

### Smuggler

- Fixed import of conflicted documents

### Tools

- Added Traffic recorder and simulator tool

{PANEL/}

{PANEL:3.0.3690 - 2015/05/22}

### Server

- `[JavaScript]` Added `IncreaseNumberOfAllowedStepsBy` method. More [here](../client-api/commands/patches/how-to-use-javascript-to-patch-your-documents#methods-objects-and-variables),
- `[JavaScript]` Debug information now contains number of steps that script took,
- `[Voron]` Less aggresive disk space allocation,
- Various performance improvements

#### [Configuration](../server/configuration/configuration-options)

- Added `Raven/AllowScriptsToAdjustNumberOfSteps`. More [here](../server/configuration/configuration-options#javascript-parser),
- Added `Raven/Voron/AllowOn32Bits`. More [here](../server/configuration/configuration-options#voron-settings),
- Added `Raven/PreventSchemaUpdate`. More [here](../server/configuration/configuration-options#data-settings).

#### Bundles

- `[SQL Replication]` Adding new replication will not force others to wait till it catches up with them

<hr />

### Studio

- Patching now displays metadata,
- Added the ability to force side-by-side index replacement,
- Added the ability to create C# class from JSON document,
- Various fixes and enhancements

<hr />

### Client API

- added `ToFacetsLazyAsync` extension method to `IQueryable`,
- conflicts can be automatically resolved by Client API during query operations if there is `IDocumentConflictListener` available

<hr />

### Installer

- installer now contains `NLog.Ignore.config` for easier logging setup

{PANEL/}

{PANEL:3.0.3660 - 2015/04/07}

### Global

- Various performance optimizations across both server and client

<hr />

### Server

- `[JavaScript]` Parser now returns more descriptive errors,
- `[JavaScript]` `PutDocument` method now returns Id of generated document,
- `[JavaScript]` Each `LoadDocument` increases maximum number of steps in script using following formula `MaxSteps = MaxSteps + (MaxSteps / 2 + (SerializedSizeOfDocumentOnDisk * AdditionalStepsPerSize))`,
- Added `debug/raw-doc` endpoint,
- Prevented high CPU and excessive GC runs under low memory conditions,
- Avoid leaking resources when failing to create a database,
- Faster JSON serialization and deserialization,
- Added backoff strategy for failing periodic exports,
- Recognize Windows users with admin rights to system database as server admins,
- Facets can now have very large number of facets

#### [Configuration](../server/configuration/configuration-options)

- Added `Raven/WorkingDir`. More [here](../server/configuration/configuration-options#data-settings),
- Added `Raven/AdditionalStepsForScriptBasedOnDocumentSize` (5 by default). More [here](../server/configuration/configuration-options#javascript-parser),
- Added `Raven/MaxServicePointIdleTime`. More [here](../server/configuration/configuration-options#http-settings),
- Added `Raven/ImplicitFetchFieldsFromDocumentMode`. More [here](../server/configuration/configuration-options#index-settings),
- Added `Raven/Replication/ForceReplicationRequestBuffering`. More [here](../server/configuration/configuration-options#replication)

#### Indexes

- [`AbstractIndexCreationTask`](../indexes/creating-and-deploying#using-abstractindexcreationtask) will add sorting to numerical fields automatically

#### Bundles

- `[Periodic Export]` Added support for remote folders for Amazon S3 and Microsoft Azure. Source [here](https://github.com/ravendb/ravendb/blob/build-3660/Raven.Abstractions/Data/PeriodicBackupSetup.cs#L45-L53),
- `[SQL Replication]` Renamed `PerformTableQuatation` to `QuoteTables` in `SqlReplicationConfig`. Source [here](https://github.com/ravendb/ravendb/blob/build-3660/Raven.Database/Bundles/SqlReplication/SqlReplicationConfig.cs#L23-L28),
- `[SQL Replication]` Added `Insert-only mode` for tables, which will prevent deletes on that table. Source [here](https://github.com/ravendb/ravendb/blob/build-3660/Raven.Database/Bundles/SqlReplication/SqlReplicationConfig.cs#L46),
- `[Replication]` Added support for index and transformer replication (including deletions). Source [here](https://github.com/ravendb/ravendb/blob/build-3660/Raven.Abstractions/Replication/ReplicationDestination.cs#L73)

<hr />

### Client API

- Indexes can be deployed side-by-side using `SideBySideExecute` from `AbstractIndexCreationTask`, `SideBySideCreateIndexes` from `IndexCreation` and directly from `DocumentStore` using `SideBySideExecuteIndex`,
- Added the ability to provide additional query to MoreLikeThis queries,
- Added `SetIndexLock` to `IDatabaseCommands`. More [here](../client-api/commands/indexes/how-to/change-index-lock-mode),
- Added `SetIndexPriority` to `IDatabaseCommands`. More [here](../client-api/commands/indexes/how-to/change-index-priority),
- Index priority can be set through `IndexPriority` property in `IndexDefinition` or `Priority` property in `AbstractIndexCreationTask`,

<hr />

### Smuggler

- Added the ability to disable versioning during smuggling using `disable-versioning-during-import` option

<hr />

### FileSystem

- Added support for @in queries (fixed the `WhereIn` method),
- Added `DeleteByQueryAsync` to `IAsyncFilesCommands`,
- Added `RegisterDeletionQuery` to `IAsyncFilesSession`,
- Added `RegisterResultsForDeletion` to `IAsyncFilesQuery`
- Deleted `progress` parameter of `UploadAsync` method in `IAsyncFilesCommands`,
- Renamed `StreamFilesAsync` to `StreamFileHeadersAsync` in `IAsyncFilesCommands`,
- Exposed `Import/Export` options in the Studio,
- Exposed synchronization settings in the Studio,
- Added concurrency checks support. Available by providing file Etags or enabling optimistic concurrency (added `DefaultUseOptimisticConcurrency` convention),
- Added `Take` and `Skip` methods to querying API,
- Fix: Registered files are tracked by session after `SaveChangesAsync` call,
- Fix: Metadata update operation creates a file revision when `Versioning Bundle` is enabled,
- Fix: Creating revisions of synchronized files when `Versioning Bundle` is enabled,
- Fix: File revisions are not synchronized to destination file systems,
- Added option `RenameOnReset` to `Versioning Bundle` configuration,
- Added ability to create `Versioning Bundle` configuration for a specific directory,
- Added `AbstractSynchronizationTrigger` trigger,
- Added querying support for numeric metadata fields,
- Renamed `SynchronizeAsync` to `StartAsync` in `IAsyncFilesSynchronizationCommands`,
- Added support for smuggling RavenFS configurations

{PANEL/}

{PANEL:3.0.3599 - 2015/02/08}

### Server

- preventing, by default, unrestricted access (`Raven/AnonymousAccess` set to `Admin`) to server when license is used. More [here](../server/configuration/license-registration),
- `[Voron]` added compaction,
- added Data Subscriptions,
- added _admin/low-memory-notification_ endpoint,
- performance improvements

#### [Configuration](../server/configuration/configuration-options)

- added `Raven/Indexing/MaxNumberOfItemsToProcessInTestIndexes`,
- added `Raven/Licensing/AllowAdminAnonymousAccessForCommercialUse`,
- added `Raven/IncrementalBackup/AlertTimeoutHours`,
- added `Raven/IncrementalBackup/RecurringAlertTimeoutDays`,
- added `Raven/NewIndexInMemoryMaxTime`,
- added `Raven/AssembliesDirectory`,
- added `Raven/Replication/IndexAndTransformerReplicationLatency`,
- added `Raven/MaxConcurrentRequestsForDatabaseDuringLoad`,
- added `Raven/Replication/MaxNumberOfItemsToReceiveInSingleBatch`,
- added `Raven/DynamicLoadBalancing`,
- added `Raven/ExposeConfigOverTheWire`

#### Indexes

- test indexes. More [here](../indexes/testing-indexes),
- side-by-side indexes. More [here](../indexes/side-by-side-indexes),
- added safe number parsing methods. More [here](../indexes/indexing-linq-extensions#parsing-numbers),
- added the ability to replicate index and transformer definitions.

#### Bundles

- `[Replication]` Added the ability to limit maximum received number of items in single replication batch using `Raven/Replication/MaxNumberOfItemsToReceiveInSingleBatch` setting,
- `[Replication]` Source server will take into account low-memory conditions on destination server and adjust batch size

<hr />

### Client API

- added `PreserveDocumentPropertiesNotFoundOnModel` convention. More [here](../client-api/configuration/conventions/request-handling#preservedocumentpropertiesnotfoundonmodel),
- **highlights** can be accessed when performing **projection** or querying **map-reduce** index. More [here](../indexes/querying/highlights#highlights--projections),
- added `IndexAndTransformerReplicationMode` convention that indicates if index and transformer definitions should be replicated when they are created using `AbstractIndexCreationTask` or `AbstractTransformerCreationTask`. More [here](../client-api/configuration/conventions/misc#indexandtransformerreplicationmode),
- added [Data Subscriptions](../client-api/data-subscriptions/what-are-data-subscriptions).

<hr />

### Studio

- more detailed _indexing performance chart_ available at `Status -> Indexing -> Indexing performance`,
- added the _persist auto index view_ available at `Status -> Debug -> Persist auto index`,
- added the _explain replication view_ available at `Status -> Debug -> Explain replication`,
- added CancellationToken support for various methods in client (e.g. in queries and commands),
- performance improvements

{PANEL/}

{PANEL:3.0.3525 - 2014/11/25}

### Server

- Voron - new [storage engine](../server/configuration/storage-engines),
- [RavenFS](../file-system/what-is-raven-fs),
- FIPS encryption support. More [here](../server/configuration/enabling-fips-compliant-encryption-algorithms),
- low memory notifications,
- simpler deployment (less files),
- using OWIN/Web API,
- added various [debug endpoints](../server/troubleshooting/debug-endpoints) and [metrics](../studio/overview/status/indexing/indexing-performance)

#### Bundles

- `[Periodic Export]` Support for full & incremental exports,
- `[Replication]` Default failover behavior for client can be defined server-side,
- `[Replication]` Default server-side conflict resolver can be defined,
- `[Replication]` Ability to generate replication topology. More [here](../studio/overview/status/replication-stats#replication-topology),
- `[SQL Replication]` Ability to define connection strings,
- `[SQL Replication]` Ability to use [custom functions](../studio/overview/settings/custom-functions),
- `[SQL Replication]` Added replication simulator,
- `[SQL Replication]` Added detailed metrics

#### Indexes

- indexing to memory - reducing number of I/O operations by flushing to disk only when certain threshold is passed,
- async index deletion,
- parallelized indexing & task execution,
- better large document handling,
- I/O bounded batching,
- attachment indexing (`LoadAttachmentForIndexing`),
- optimized new index creation,
- better control for Cartesian/fanout indexing,
- better auto-index generation,
- ...more details [here](http://ayende.com/blog/168417/what-is-new-in-ravendb-3-0-indexing-backend) and [here](http://ayende.com/blog/168418/what-is-new-in-ravendb-3-0-indexing-enhancements)

#### Transformers

- ability to nest transformers. More [here](../transformers/nesting-transformers)

<hr />

### Client API

- [Java API](http://ayende.com/blog/168354/what-is-new-in-ravendb-3-0-jvm-client-api),
- fully async (sync version is using async client underneath),
- full support for Lazy async,
- full support for Lazy timings,
- Embedded and Remote clients use the same code,
- administrative operations (both database and server-wide) were separated and can be found in `store.Commands.Admin` and `store.Commands.GlobalAdmin`,
- Bulk insert errors are handled immediately, not at the end of operation,
- Bulk insert detect document changes and skip updated if inserted documents are the same (this way documents will not have to be re-indexed or re-replicated),
- better memory management - less allocations,
- missing properties retention - if there are more properties in the document on server-side than in client-side, during update (load -> change -> save) all extra properties will be retained,
- added `WhatChanged` and `HasChanges` to session. More [here](../client-api/session/how-to/check-if-there-are-any-changes-on-a-session)
- added `GetIndexMergeSuggestions`. More [here](../client-api/commands/indexes/how-to/get-index-merge-suggestions).
- patching (JavaScript) now supports [custom functions](../studio/overview/settings/custom-functions),
- optimistic concurrency can be turned on globally using `store.Conventions.DefaultUseOptimisticConcurrency`,
- `EmbeddedDocumentStore` was moved to `Raven.Database.dll`,
- ...more details [here](http://ayende.com/blog/168386/what-is-new-in-ravendb-3-0-client-side)

#### Querying

- renamed `LuceneQuery` to `DocumentQuery`,
- ability to return detailed query timings. More [here](../client-api/session/querying/how-to-customize-query#showtimings),
- ability to cancel long-running queries. More [here](../studio/overview/status/running-tasks),
- ability to explain query, by using [ExplainScores]() in `DocumentQuery`,
- `MoreLikeThisQuery` now supports includes. More [here](../client-api/session/how-to/use-morelikethis),

<hr />

### Smuggler

- Server to server smuggling. More [here](../server/administration/exporting-and-importing-data#moving-data-between-two-databases)

<hr />

### Studio

- HTML5 [Studio](../studio/accessing-studio),
- added various [debug endpoints](../server/troubleshooting/debug-endpoints) and [metrics](../studio/overview/status/index-stats-and-metrics),
- [Map-Reduce Visualizer](../studio/overview/status/map-reduce-visualizer),
- ability to view/kill [running tasks](../studio/overview/status/running-tasks),
- ability to create [debug info package](../studio/overview/status/gather-debug-info) that can be send with [support ticket](../server/troubleshooting/sending-support-ticket),
- ability to connect to [server logs](../studio/management/admin-logs),
- ability to view server traffic using [traffic watch](../studio/management/traffic-watch),
- added I/O performance test. More [here](../studio/management/io-test),
- ..and many more

{PANEL/}

