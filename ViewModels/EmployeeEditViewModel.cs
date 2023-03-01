namespace EmployeeManagement.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; } 
        public string ExistingPhotoPath { get; set; }
    }
}
