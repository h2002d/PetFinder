//
//  LTCodecsEnumTagsEventArgs.h
//  Leadtools.Codecs
//
//  Copyright © 1991-2019 LEAD Technologies, Inc. All rights reserved.
//

#import <Leadtools/LTRasterTagMetadata.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTCodecsEnumTagsEventArgs : NSObject

@property (nonatomic, assign)           BOOL cancel;

@property (nonatomic, assign, readonly) NSInteger tagId;

@property (nonatomic, assign, readonly) NSUInteger count;

@property (nonatomic, assign, readonly) LTRasterTagMetadataDataType metadataType;

@end

NS_ASSUME_NONNULL_END
