//
//  LTGetLinearVoiLookupTableCommand.h
//  Leadtools.ImageProcessing.Core
//
//  Copyright © 1991-2019 LEAD Technologies, Inc. All rights reserved.
//

#import <Leadtools/LTRasterCommand.h>

typedef NS_OPTIONS(NSUInteger, LTGetLinearVoiLookupTableCommandFlags) {
    LTGetLinearVoiLookupTableCommandFlagsNone   = 0x0000,
};

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTGetLinearVoiLookupTableCommand : LTRasterCommand

@property (nonatomic, assign, readonly) double center;
@property (nonatomic, assign, readonly) double width;
@property (nonatomic, assign)           LTGetLinearVoiLookupTableCommandFlags flags;

- (instancetype)initWithFlags:(LTGetLinearVoiLookupTableCommandFlags)flags NS_DESIGNATED_INITIALIZER;

@end

NS_ASSUME_NONNULL_END
