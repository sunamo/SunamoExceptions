

namespace
#if SunamoCl
SunamoCl
#else
SunamoExceptions
#endif
;


public interface IAIWinPi
{
    Action<string> PHWinPiRunAsDesktopUserNoAdmin { get; set; }
}
