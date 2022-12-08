using Pizza.Application.DTOs.Requests;

namespace Pizza.Application.Validators;

public interface ICreateOrderValidator
{
    void ValidateAndThrow(CreateOrderRequest request);
}
