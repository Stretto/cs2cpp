#ifdef _MSC_VER
	typedef __int8 int8_t;
	typedef __int16 int16_t;
	typedef __int32 int32_t;
	typedef __int64 int64_t;
	typedef unsigned __int8 uint8_t;
	typedef unsigned __int16 uint16_t;
	typedef unsigned __int32 uint32_t;
	typedef unsigned __int64 uint64_t;
	
#elif __GNUC__ >= 3
	typedef signed char int8_t;
	typedef short int16_t;
	typedef int int32_t;
	typedef long long int64_t;
	typedef unsigned char uint8_t;
	typedef unsigned short uint16_t;
	typedef unsigned int uint32_t;
	typedef unsigned long long uint64_t;
	extern void *__builtin_memset(void *,int32_t,uint32_t);
	#define memset __builtin_memset
#endif

typedef bool i1;
typedef int8_t i8;
typedef int16_t i16;
typedef int32_t i32;
typedef int64_t i64;
typedef uint8_t u8;
typedef uint16_t u16;
typedef uint32_t u32;
typedef uint64_t u64;

typedef i32 (*anyFn)(...);

extern "C" void* calloc(u32);