//
//  LTConvertUnsignedToSignedCommand.h
//  Leadtools.ImageProcessing.Core
//
//  Copyright © 1991-2019 LEAD Technologies, Inc. All rights reserved.
//

#import <Leadtools/LTRasterCommand.h>

typedef NS_ENUM(NSInteger, LTConvertUnsignedToSignedCommandType) {
    LTConvertUnsignedToSignedCommandTypeProcessRangeOnly    = 0x0001,
    LTConvertUnsignedToSignedCommandTypeProcessOutSideRange = 0x0002
};

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTConvertUnsignedToSignedCommand : LTRasterCommand

@property (nonatomic, assign) LTConvertUnsignedToSignedCommandType type;

- (instancetype)initWithType:(LTConvertUnsignedToSignedCommandType)type NS_DESIGNATED_INITIALIZER;

@end

NS_ASSUME_NONNULL_END
