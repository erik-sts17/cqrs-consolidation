namespace CQRS.Domain.Entities
{
    public sealed class Member : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public bool? Active { get; set; }

        public Member(int id, string? firstName, string? lastName, string? gender, string? email, bool? active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Active = active;
        }

        public Member(string? firstName, string? lastName, string? gender, string? email, bool? active)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Active = active;
        }

        public void Update(string? firstName, string? lastName, string? gender, string? email, bool? active)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Active = active;
        }
    }
}