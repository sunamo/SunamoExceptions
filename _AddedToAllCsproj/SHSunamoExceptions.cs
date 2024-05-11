namespace
#if SunamoArgs
SunamoArgs
#elif SunamoAsync
SunamoAsync
#elif SunamoAttributes
SunamoAttributes
#elif SunamoBts
SunamoBts
#elif SunamoChar
SunamoChar
#elif SunamoCl
SunamoCl
#elif SunamoClearScript
SunamoClearScript
#elif SunamoClipboard
SunamoClipboard
#elif SunamoCollectionOnDrive
SunamoCollectionOnDrive
#elif SunamoCollections
SunamoCollections
#elif SunamoCollectionsChangeContent
SunamoCollectionsChangeContent
#elif SunamoCollectionsGeneric
SunamoCollectionsGeneric
#elif SunamoCollectionsGenericShared
SunamoCollectionsGenericShared
#elif SunamoCollectionsIndexesWithNull
SunamoCollectionsIndexesWithNull
#elif SunamoCollectionsNonGeneric
SunamoCollectionsNonGeneric
#elif SunamoCollectionsShared
SunamoCollectionsShared
#elif SunamoCollectionsValuesTableGrid
SunamoCollectionsValuesTableGrid
#elif SunamoCollectionWithoutDuplicates
SunamoCollectionWithoutDuplicates
#elif SunamoColors
SunamoColors
#elif SunamoCompare
SunamoCompare
#elif SunamoConverters
SunamoConverters
#elif SunamoCrypt
SunamoCrypt
#elif SunamoCSharp
SunamoCSharp
#elif SunamoCsv
SunamoCsv
#elif SunamoData
SunamoData
#elif SunamoDateTime
SunamoDateTime
#elif SunamoDebugCollection
SunamoDebugCollection
#elif SunamoDebugging
SunamoDebugging
#elif SunamoDebugIO
SunamoDebugIO
#elif SunamoDelegates
SunamoDelegates
#elif SunamoDevCode
SunamoDevCode
#elif SunamoDictionary
SunamoDictionary
#elif SunamoEmbeddedResources
SunamoEmbeddedResources
#elif SunamoEnums
SunamoEnums
#elif SunamoEnumsHelper
SunamoEnumsHelper
#elif SunamoExceptions
SunamoExceptions
#elif SunamoExtensions
SunamoExtensions
#elif SunamoFileExtensions
SunamoFileExtensions
#elif SunamoFileIO
SunamoFileIO
#elif SunamoFileSystem
SunamoFileSystem
#elif SunamoFluentFtp
SunamoFluentFtp
#elif SunamoFtp
SunamoFtp
#elif SunamoFubuCore
SunamoFubuCore
#elif SunamoFubuCsProjFile
SunamoFubuCsProjFile
#elif SunamoGitBashBuilder
SunamoGitBashBuilder
#elif SunamoGoogleSheets
SunamoGoogleSheets
#elif SunamoHtml
SunamoHtml
#elif SunamoHttp
SunamoHttp
#elif SunamoIni
SunamoIni
#elif SunamoInterfaces
SunamoInterfaces
#elif SunamoJson
SunamoJson
#elif SunamoLang
SunamoLang
#elif SunamoLogger
SunamoLogger
#elif SunamoLogMessage
SunamoLogMessage
#elif SunamoMail
SunamoMail
#elif SunamoMarkdown
SunamoMarkdown
#elif SunamoMime
SunamoMime
#elif SunamoMsgReader
SunamoMsgReader
#elif SunamoNuGetProtocol
SunamoNuGetProtocol
#elif SunamoNumbers
SunamoNumbers
#elif SunamoNumbersShared
SunamoNumbersShared
#elif SunamoOctokit
SunamoOctokit
#elif SunamoPackageJson
SunamoPackageJson
#elif SunamoParsing
SunamoParsing
#elif SunamoPercentCalculator
SunamoPercentCalculator
#elif SunamoPInvoke
SunamoPInvoke
#elif SunamoPlatformUwpInterop
SunamoPlatformUwpInterop
#elif SunamoPS
SunamoPS
#elif SunamoRandom
SunamoRandom
#elif SunamoReflection
SunamoReflection
#elif SunamoRegex
SunamoRegex
#elif SunamoRoslyn
SunamoRoslyn
#elif SunamoRss
SunamoRss
#elif SunamoSerializer
SunamoSerializer
#elif SunamoShared
SunamoShared
#elif SunamoSolutionsIndexer
SunamoSolutionsIndexer
#elif SunamoStopwatch
SunamoStopwatch
#elif SunamoString
SunamoString
#elif SunamoStringData
SunamoStringData
#elif SunamoStringFormat
SunamoStringFormat
#elif SunamoStringGetLines
SunamoStringGetLines
#elif SunamoStringGetString
SunamoStringGetString
#elif SunamoStringJoin
SunamoStringJoin
#elif SunamoStringJoinPairs
SunamoStringJoinPairs
#elif SunamoStringParts
SunamoStringParts
#elif SunamoStringReplace
SunamoStringReplace
#elif SunamoStringShared
SunamoStringShared
#elif SunamoStringSplit
SunamoStringSplit
#elif SunamoStringSubstring
SunamoStringSubstring
#elif SunamoStringTrim
SunamoStringTrim
#elif SunamoText
SunamoText
#elif SunamoTextOutputGenerator
SunamoTextOutputGenerator
#elif SunamoThisApp
SunamoThisApp
#elif SunamoThread
SunamoThread
#elif SunamoTidy
SunamoTidy
#elif SunamoTwoWayDictionary
SunamoTwoWayDictionary
#elif SunamoTypeOfMessage
SunamoTypeOfMessage
#elif SunamoUnderscore
SunamoUnderscore
#elif SunamoUri
SunamoUri
#elif SunamoUriWebServices
SunamoUriWebServices
#elif SunamoValues
SunamoValues
#elif SunamoVcf
SunamoVcf
#elif SunamoWikipedia
SunamoWikipedia
#elif SunamoWinStd
SunamoWinStd
#elif SunamoXlfKeys
SunamoXlfKeys
#elif SunamoXliffParser
SunamoXliffParser
#elif SunamoXml
SunamoXml
#elif SunamoYaml
SunamoYaml
#elif SunamoYouTube
SunamoYouTube
#else
SunamoExceptionsAddedToAllCsproj
#endif
;
internal class SHSunamoExceptions
{
    public static string NullToStringOrDefault(object n)
    {
        //return NullToStringOrDefault(n, null);
        return n == null ? " " + Consts.nulled : AllStrings.space + n;
    }
    public static string TrimEnd(string name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);

        return name;
    }
}
