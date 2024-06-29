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
public partial class TypesDelegates
{
    public static readonly Type tAction = typeof(Action);
    public static readonly Type tFuncTask = typeof(Func<Task>);
}