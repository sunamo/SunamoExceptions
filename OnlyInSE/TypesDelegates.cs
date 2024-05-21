using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace
#if SunamoAsync
SunamoAsync
#elif SunamoCl
SunamoCl
#elif SunamoShared
    SunamoShared
#else
SunamoExceptions
#endif
;
public partial class Types
{
    public static readonly Type tVoidVoid = typeof(VoidVoid);
    public static readonly Type tTaskVoid = typeof(TaskVoid);
}