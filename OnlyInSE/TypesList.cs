namespace
#if SunamoShared
SunamoShared
#else SunamoExceptionsOnlyInSE
SunamoExceptionsOnlyInSE
#endif
;

public class TypesList
{
    public static readonly Type tLong = typeof(List<long>);
    public static readonly Type tString = typeof(List<string>);
}
