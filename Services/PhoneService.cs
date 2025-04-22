using Microsoft.AspNetCore.Mvc;

public class PhoneService : IPhoneService {
    private readonly PhoneRepository _phoneRepository;
    public PhoneService(PhoneRepository phoneRepository) {
        _phoneRepository = phoneRepository;
    }

    public async Task<PhoneModel> Add([FromBody] PhoneModel phone) {
        PhoneValidator phoneValidator = new PhoneValidator();
        var result = await phoneValidator.ValidateAsync(phone);
        string errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
        if (!result.IsValid) {
            throw new ArgumentException(errors);
        }

        PhoneModel createdPhone = await _phoneRepository.Add(phone);
        return createdPhone;
    }

    public async Task<PhoneModel> FindById(int id) {
        if (id <= 0) {
            throw new ArgumentNullException(nameof(id), "Id invalid");
        }

        PhoneModel phone = await _phoneRepository.FindById(id);
        if (phone == null) {
            throw new KeyNotFoundException("Phone not found");
        }

        return phone;
    }

    public async Task<List<PhoneModel>> FindAll() {
        List<PhoneModel> phoneList = await _phoneRepository.FindAll();
        return phoneList;
    }

    public async Task<PhoneModel> Update(int id, [FromBody] PhoneModel phone) {
        PhoneValidator phoneValidator = new PhoneValidator();
        var result = await phoneValidator.ValidateAsync(phone);
        string errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
        if (!result.IsValid) {
            throw new ArgumentException(errors);
        }

        PhoneModel findedPhone = await _phoneRepository.FindById(id);
        PhoneModel updatedPhone = await _phoneRepository.Update(phone, findedPhone);
        if (updatedPhone == null) {
            throw new KeyNotFoundException("Phone not found");
        }

        return updatedPhone;
    }

    public async Task<PhoneModel> Remove(int id) {
        PhoneModel findedPhone = await _phoneRepository.FindById(id);
        PhoneModel deletedPhone = await _phoneRepository.Remove(findedPhone);
        return deletedPhone;
    }


}