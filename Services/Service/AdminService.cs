using LibraryManagementApi.Repositories.Interface;
using LibraryManagementApi.Services.Interface;
using System.Collections.Generic;

namespace LibraryManagementApi.Services.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<Models.Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public List<Models.Admin> Get(int id)
        {
            return _adminRepository.Get(id);
        }

        public void Add(Models.Admin admin)
        {
            _adminRepository.Add(admin);
        }

        public void Update(Models.Admin admin)
        {
            _adminRepository.Update(admin);
        }

        public void Delete(int id)
        {
            _adminRepository.Delete(id);
        }
    }
}