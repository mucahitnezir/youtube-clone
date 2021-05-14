using System;
using System.Collections.Generic;
using VideoApp.Core.Utilities.Results;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Abstract
{
    public interface IChannelService
    {
        IDataResult<IList<Channel>> GetList();
        Channel GetById(Guid channelId);
        Channel GetBySlug(string slug);
        IResult Add(ChannelDto channelDto);
        IResult Update(Guid id, ChannelUpdateDto channelUpdateDto);
    }
}