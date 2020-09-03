//
//  LTSharpenCommand.h
//  Leadtools.ImageProcessing.Effects
//
//  Copyright © 1991-2019 LEAD Technologies, Inc. All rights reserved.
//

#import <Leadtools/LTRasterCommand.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTSharpenCommand : LTRasterCommand

@property (nonatomic, assign) NSInteger sharpness;

- (instancetype)initWithSharpness:(NSInteger)sharpness NS_DESIGNATED_INITIALIZER;

@end

NS_ASSUME_NONNULL_END