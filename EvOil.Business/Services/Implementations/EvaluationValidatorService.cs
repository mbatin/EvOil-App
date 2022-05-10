using System.ComponentModel.DataAnnotations;
using EvOil.Business.DataTransferObjects.Evaluations;
using EvOil.Business.Services.Abstractions;
using EvOil.Domain.Models;

namespace EvOil.Business.Services.Implementations;

public class EvaluationValidatorService : IEvaluationValidatorService
{
    public void ValidateEvaluation(AddEvaluationDto addEvaluationDto)
    {
        ValidateId(addEvaluationDto.Id);
        ValidateUsername(addEvaluationDto.Username);
        ValidateCodeName(addEvaluationDto.CodeName);
        ValidateInflamed(addEvaluationDto.Inflamed);
        ValidateMoldy(addEvaluationDto.Moldy);
        ValidateSour(addEvaluationDto.Sour);
        ValidateFrosted(addEvaluationDto.Frosted);
        ValidateBurned(addEvaluationDto.Burned);
        ValidateFruity(addEvaluationDto.Fruity);
        ValidateSpicy(addEvaluationDto.Spicy);
        ValidateBitter(addEvaluationDto.Bitter);
    }

    public static void ValidateId(int id)
    {
        if (id == 0000)
        {
            throw new ValidationException("Id is empty!");
        }

        if (id < Evaluation.MinValue || id > Evaluation.MaxValue)
        {
            var message = $"Id must be number between {Evaluation.MinValue} and {Evaluation.MaxValue}!";
            throw new ValidationException(message);
        }
    }

    public static void ValidateUsername(string? username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ValidationException("Username is empty!");
        }

        if (username.Length >= Evaluation.MaxUsernameLength)
        {
            var message = $"Username is too long! Username must be less than {Evaluation.MaxUsernameLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateCodeName(string? codeName)
    {
        if (string.IsNullOrWhiteSpace(codeName))
        {
            throw new ValidationException("Code name is empty!");
        }

        if (codeName.Length >= Evaluation.MaxCodeNameLength)
        {
            var message = $"Code name is too long! It must be less than {Evaluation.MaxCodeNameLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateInflamed(float inflamed)
    {
        if (inflamed < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (inflamed > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateMoldy(float moldy)
    {
        if (moldy < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (moldy > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateSour(float sour)
    {
        if (sour < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (sour > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateFrosted(float frosted)
    {
        if (frosted < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (frosted > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateBurned(float burned)
    {
        if (burned < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (burned > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateFruity(float fruity)
    {
        if (fruity < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (fruity > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateSpicy(float spicy)
    {
        if (spicy < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (spicy > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }

    public static void ValidateBitter(float bitter)
    {
        if (bitter < Evaluation.MinGradeLength)
        {
            throw new ValidationException("Grade is empty!");
        }

        if (bitter > Evaluation.MaxGradeLength)
        {
            var message = $"Grade must be number between {Evaluation.MinGradeLength} and {Evaluation.MinGradeLength}";
            throw new ValidationException(message);
        }
    }
}
