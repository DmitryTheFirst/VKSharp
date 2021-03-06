﻿using VKSharp.Core.Enums;

namespace VKSharp.Core.Entities {
    public class Attachment  {
        public AttachmentType? Type { get; set; }
        public Photo Photo { get; set; }
        public PostedPhoto PostedPhoto { get; set; }
        public Video Video { get; set; }
        public Audio Audio { get; set; }
        public Graffity Graffity { get; set; }
        public Document Doc { get; set; }
        public Link Link { get; set; }
        public Note Note { get; set; }
        //todo:app
        public Poll Poll { get; set; }
        //todo:wikipage
        public PhotoAlbum Album { get; set; }

        public override string ToString() {
            switch ( Type ) {
                case AttachmentType.Photo:
                    return $"photo{Photo.OwnerId}_{Photo.Id}";
                case AttachmentType.PostedPhoto:
                    return $"photo{PostedPhoto.OwnerId}_{PostedPhoto.Id}";
                case AttachmentType.Video:
                    return $"video{Video.OwnerId}_{Video.Id}";
                case AttachmentType.Audio:
                    return $"audio{Audio.OwnerId}_{Audio.Id}";
                case AttachmentType.Doc:
                    return $"doc{Audio.OwnerId}_{Audio.Id}";
                case AttachmentType.Link:
                    return Link.Url;
            }
            return "Attached "+Type;
        }
    }
}
