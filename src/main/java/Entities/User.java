package Entities;

import java.time.LocalDate;

public class User {
    private long userId;
    private String fullName;
    private LocalDate DoB;
    private String phone;
    private String address;
    private String email;
    private String company;
    private LocalDate createdOn;

    public User(String fullName, LocalDate DoB, String phone, String address, String email) {
        this.fullName = fullName;
        this.DoB = DoB;
        this.phone = phone;
        this.address = address;
        this.email = email;

        setCreatedOn(LocalDate.now());
    }

    public User(String fullName, LocalDate doB, String phone, String address, String email, String company, LocalDate createdOn) {
        new User(fullName, doB, phone, address, email);
        this.company = company;
        this.createdOn = createdOn;
    }

    public long getUserId() {
        return userId;
    }

    public String getFullName() {
        return fullName;
    }

    public LocalDate getDoB() {
        return DoB;
    }

    public String getPhone() {
        return phone;
    }

    public String getAddress() {
        return address;
    }

    public String getEmail() {
        return email;
    }

    public String getCompany() {
        return company;
    }

    public LocalDate getCreatedOn() {
        return createdOn;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public void setDoB(LocalDate doB) {
        DoB = doB;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setCompany(String company) {
        this.company = company;
    }

    public void setCreatedOn(LocalDate createdOn) {
        this.createdOn = createdOn;
    }
}
