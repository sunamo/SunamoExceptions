namespace
#if SunamoAsync
SunamoAsync
#elif SunamoCl
SunamoCl
#elif SunamoShared
    SunamoShared
#else
SunamoExceptions.OnlyInSE
#endif
;
public class TypesDelegates
{
    public static readonly Type tAction = typeof(Action);
    public static readonly Type tFuncTask = typeof(Func<Task>);
}
