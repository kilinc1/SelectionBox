using System.Collections.Generic;
using System.Windows;

namespace StudentList
{
    public partial class MainWindow : Window
    {
        private List<Student> students = new List<Student>();

        public MainWindow()
        {
            InitializeComponent();
            studentListBox.ItemsSource = students;
            studentComboBox.ItemsSource = students;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            int csiGrade = int.Parse(csiGradeTextBox.Text);
            int genEdGrade = int.Parse(genEdGradeTextBox.Text);

            Student newStudent = new Student(firstName, lastName, csiGrade, genEdGrade);
            students.Add(newStudent);

            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            csiGradeTextBox.Clear();
            genEdGradeTextBox.Clear();

            studentListBox.Items.Refresh();
            studentComboBox.Items.Refresh();
        }

        private void StudentListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (studentListBox.SelectedItem != null)
            {
                Student selectedStudent = (Student)studentListBox.SelectedItem;

                firstNameTextBox.Text = selectedStudent.FirstName;
                lastNameTextBox.Text = selectedStudent.LastName;
                csiGradeTextBox.Text = selectedStudent.CSIGrade.ToString();
                genEdGradeTextBox.Text = selectedStudent.GenEdGrade.ToString();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentListBox.SelectedItem != null)
            {
                Student selectedStudent = (Student)studentListBox.SelectedItem;
                students.Remove(selectedStudent);
                studentListBox.Items.Refresh();
                studentComboBox.Items.Refresh();
            }
        }

        private void StudentComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (studentComboBox.SelectedItem != null)
            {
                Student selectedStudent = (Student)studentComboBox.SelectedItem;

                firstNameTextBox.Text = selectedStudent.FirstName;
                lastNameTextBox.Text = selectedStudent.LastName;
                csiGradeTextBox.Text = selectedStudent.CSIGrade.ToString();
                genEdGradeTextBox.Text = selectedStudent.GenEdGrade.ToString();
            }
        }
    }
}
