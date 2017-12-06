#include <mono/metadata/object.h>
#include <mono/metadata/metadata.h>
#include <mono/metadata/class.h>
#include <mono/metadata/appdomain.h>
#include <mono/metadata/loader.h>

int
internalCount (MonoArray *arr,int index)
{
    MonoString* el=mono_array_get(arr,MonoString *,index);
    int len=mono_string_length(el);
    int sum=0;
    mono_unichar2 *str=mono_string_chars(el);
    int i;

    for(i=0;i<len;i++)
    {
        sum+=str[i];
    }

    return sum;
}

void
init()
{
    mono_add_internal_call ("PInvokePerf.PerformanceTest::InternalCount(string[],int)",internalCount);
}
