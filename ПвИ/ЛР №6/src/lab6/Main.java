package lab6;

import lab6.Second.Third.AAA;

import java.util.Date;

public class Main {

    public static void main(String[] args) {
        AAA person = new AAA();

        person.setUniversity("Belstu");
        person.setBirthday(2001, 11, 27);
        person.setName("Yahor");
        person.setSurname("Anikeyenka");
        person.setFatherName("Vyacheslavovich");
        person.setFirstDate(new Date(2019 - 1900, 8, 1));

        System.out.println(person.Name);
        System.out.println(person.Surname);
        System.out.println(person.FatherName);
        System.out.println(person.getBirthday());
        System.out.println(person.getUniversity());
        System.out.println(person.getFirstDate());
    }
}
