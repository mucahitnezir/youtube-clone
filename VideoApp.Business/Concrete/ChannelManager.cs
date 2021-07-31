using System;
using System.Collections.Generic;
using VideoApp.Business.Abstract;
using VideoApp.Core.Utilities.Results;
using VideoApp.DataAccess.Abstract;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Concrete
{
    public class ChannelManager : IChannelService
    {
        private readonly IUserService _userService;
        private readonly IChannelDal _channelDal;

        public ChannelManager(IChannelDal channelDal, IUserService userService)
        {
            _channelDal = channelDal;
            _userService = userService;
        }

        public IDataResult<IList<Channel>> GetList()
        {
            var channels = _channelDal.GetList();
            return new SuccessDataResult<IList<Channel>>(channels);
        }

        public Channel GetById(Guid channelId)
        {
            return _channelDal.Get(c => c.Id == channelId);
        }

        public Channel GetBySlug(string slug)
        {
            return _channelDal.Get(c => c.Slug == slug);
        }

        public IResult Add(ChannelDto channelDto)
        {
            var userExist = _userService.GetById(channelDto.UserId);
            if (userExist == null)
            {
                return new ErrorResult("Invalid user");
            }

            var channel = new Channel
            {
                Name = channelDto.Name,
                Verified = false,
                UserId = channelDto.UserId
            };

            if (!_channelDal.Add(channel))
            {
                return new ErrorResult("Channel cannot created!");
            }

            channel.Slug = channel.Id.ToString();
            _channelDal.Update(channel);

            return new SuccessResult("Channel created.");
        }

        public IResult Update(Guid id, ChannelUpdateDto channelUpdateDto)
        {
            var channel = GetById(id);

            if (channel == null)
            {
                return new ErrorResult("Channel cannot found!");
            }

            channel.Name = channelUpdateDto.Name;
            channel.Slug = channelUpdateDto.Slug;
            channel.ImagePath = channelUpdateDto.ImagePath;

            return _channelDal.Update(channel)
                ? new SuccessResult("Channel updated.")
                : new ErrorResult("Channel cannot updated!");
        }
    }
}
