namespace
#if SunamoCl
SunamoCl
#elif SunamoShared
SunamoShared
#elif SunamoEnums
SunamoEnums
#else
SunamoExceptions
#endif
;
public record AIAssembly<T>(Action<T> a, T t);
public class AI
{
    /// <summary>
    ///     For 2+ add here () as result
    /// </summary>
    /// <param name="winPi"></param>
    /// <returns></returns>
    public static void Init(AIInitArgs a)
    {
        // dekonstrukci tu nemůžu použít protože mi auto dekonstruuje i AIAssembly a tedy vrácené objekty jsou 2x a bylo by těžké se v tom vyznat
        //var (winPi) = a;
        if (a.winPi != null) a.winPi.a(a.winPi.t);
        AIStore.winPi = a.winPi?.t;
    }
}