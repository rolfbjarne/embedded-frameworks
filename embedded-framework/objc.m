#include <Foundation/Foundation.h>

@interface MyObjectiveCClass : NSObject
+ (NSString *) callMethod;
@end

@implementation MyObjectiveCClass
+ (NSString *) callMethod
{
	return @"My Objective-C method was called";
}
@end