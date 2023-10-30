using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using ThinkLogic.Common.InputOutput;
using ThinkLogic.Common.Models;
using ThinkLogic.Domain.Interfaces.Validator;

namespace ThinkLogic.Domain.Implementations.Validator
{
    public class ScheduledEventValidator : IValidator<ScheduledEvent>
    {
        public Dictionary<string, Func<ScheduledEvent, TLResponse<bool>>> _validations = new Dictionary<string, Func<ScheduledEvent, TLResponse<bool>>>();

        public ScheduledEventValidator()
        {
            _validations.Add("INSERT", ValidateInsert);
            _validations.Add("UPDATE", ValidateUpdate);
        }


        public TLResponse<bool> IsValid(ScheduledEvent value, string context)
        {
            return _validations[context](value);
        }

        private TLResponse<bool> ValidateUpdate(ScheduledEvent value)
        {
            var result = new TLResponse<bool>();

            if (value.Id <= 0)
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.Id)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (string.IsNullOrWhiteSpace(value.Description))
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.Description)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (string.IsNullOrWhiteSpace(value.Title))
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.Title)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (string.IsNullOrWhiteSpace(value.Location))
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.Location)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (value.StartDate is null)
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.StartDate)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (value.EndDate is null)
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.EndDate)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            return result;
        }

        private TLResponse<bool> ValidateInsert(ScheduledEvent value) 
        {
            var result = new TLResponse<bool>();


            if (string.IsNullOrWhiteSpace(value.Description))
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.Description)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (string.IsNullOrWhiteSpace(value.Title))
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.Title)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (string.IsNullOrWhiteSpace(value.Location))
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.Location)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (value.StartDate is null)
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.StartDate)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }

            if (value.EndDate is null)
            {
                result.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"'{nameof(value.EndDate)}' is required",
                    Title = "X",
                    Type = Message.MessageTypeEnum.Validation
                });
            }


            return result;
        }

       
    }
}
