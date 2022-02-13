package lab6.Second;

import lab6.Person;

import java.util.Date;

public interface Student extends Person {
    int LimitUniversityLength = 100;
    void setFirstDate(java.util.Date d);
    Date getFirstDate();
    void setUniversity(String u);
    String getUniversity();
}
