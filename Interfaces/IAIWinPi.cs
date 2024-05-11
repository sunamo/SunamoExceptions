

namespace
#if SunamoCl
SunamoCl
#else
    SunamoExceptions.Interfaces
#endif
;


public interface IAIWinPi
{
    Action<string> PHWinPiRunAsDesktopUserNoAdmin { get; set; }
}
