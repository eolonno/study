package lab6.Second.Third;

import lab6.Second.Student;
import java.util.Date;

public class AAA implements Student {
    public String Surname;
    public String Name;
    public String FatherName;
    private String University;
    private Date Birthday;
    private Date FirstDate;
    public void setSurname(String surname) {
        this.Surname = surname;
    }

    @Override
    public void setName(String name) {
        this.Name = name;
    }

    @Override
    public void setFatherName(String fatherName) {
        this.FatherName = fatherName;
    }

    @Override
    public Date getBirthday() {
        return Birthday;
    }

    @Override
    public void setBirthday(int yyyy, int mm, int dd) {
        this.Birthday = new Date(yyyy - Limityyyy, mm, dd);
    }

    @Override
    public void setFirstDate(Date d) {
        this.FirstDate = d;
    }

    @Override
    public Date getFirstDate() {
        return FirstDate;
    }

    @Override
    public void setUniversity(String u) {
        this.University = u;
    }

    @Override
    public String getUniversity() {
        return University;
    }
}
