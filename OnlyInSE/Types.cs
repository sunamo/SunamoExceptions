
using System.Collections;
using System.Text;

namespace
#if SunamoBts
SunamoBts
#elif SunamoCl
SunamoCl
#elif SunamoCollections
SunamoCollections
#elif SunamoCollectionsShared
SunamoCollectionsShared
#elif SunamoCSharp
SunamoCSharp
#elif SunamoDevCode
SunamoDevCode
#elif SunamoFubuCsProjFile
SunamoFubuCsProjFile
#elif SunamoNuGetProtocol
SunamoNuGetProtocol
#elif SunamoNumbers
SunamoNumbers
#elif SunamoReflection
SunamoReflection
#elif SunamoShared
SunamoShared
#elif SunamoString
SunamoString
#elif SunamoStringGetString
SunamoStringGetString
#elif SunamoStringJoin
SunamoStringJoin
#elif SunamoVcf
SunamoVcf
#elif SunamoAsync
SunamoAsync
#elif SunamoArgs
SunamoArgs
#elif SunamoAttributes
SunamoAttributes
#elif SunamoChar
SunamoChar
#elif SunamoClearScript
SunamoClearScript
#elif SunamoClipboard
SunamoClipboard
#elif SunamoCollectionOnDrive
SunamoCollectionOnDrive
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
#elif SunamoRegex
SunamoRegex
#elif SunamoRoslyn
SunamoRoslyn
#elif SunamoRss
SunamoRss
#elif SunamoSerializer
SunamoSerializer
#elif SunamoSolutionsIndexer
SunamoSolutionsIndexer
#elif SunamoStopwatch
SunamoStopwatch
#elif SunamoStringData
SunamoStringData
#elif SunamoStringFormat
SunamoStringFormat
#elif SunamoStringGetLines
SunamoStringGetLines
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
SunamoExceptions
#endif
;

public partial class Types
{
    

    public static readonly Type tObject = typeof(object);

    public static readonly Type tStringBuilder = typeof(StringBuilder);

    public static readonly Type tIEnumerable = typeof(IEnumerable);

    public static readonly Type tString = typeof(string);
    public static readonly Type tFloat = typeof(float);
    public static readonly Type tDouble = typeof(double);
    public static readonly Type tInt = typeof(int);
    public static readonly Type tLong = typeof(long);
    public static readonly Type tShort = typeof(short);
    public static readonly Type tDecimal = typeof(decimal);
    public static readonly Type tSbyte = typeof(sbyte);
    public static readonly Type tByte = typeof(byte);
    public static readonly Type tUshort = typeof(ushort);
    public static readonly Type tUint = typeof(uint);
    public static readonly Type tUlong = typeof(ulong);
    public static readonly Type tDateTime = typeof(DateTime);
    public static readonly Type tBinary = typeof(byte[]);
    public static readonly Type tChar = typeof(char);

    public static readonly List<Type> allBasicTypes = new()
{
tObject, tString, tStringBuilder, tInt, tDateTime,
tDouble, tFloat, tChar, tBinary, tByte, tShort, tBinary, tLong, tDecimal, tSbyte, tUshort, tUint, tUlong
};

    public static readonly Type list = typeof(IList);

    #region Same seria as in DefaultValueForTypeT

    public static readonly Type tBool = typeof(bool);

    #region Signed numbers

    #endregion

    #region Unsigned numbers

    #endregion


    public static readonly Type tGuid = typeof(Guid);

    #endregion
}
