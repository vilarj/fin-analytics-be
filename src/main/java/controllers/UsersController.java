package controllers;

import Entities.User;
import Services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.time.LocalDate;

@RestController
@RequestMapping("v1/api/Users")
public class UsersController {

    @Autowired
    private UserService userService;

    @PostMapping("/createUser")
    public User CreateUser(String fullName, LocalDate DoB, String phone, String address, String email) {
        return userService.CreateUser(fullName, DoB, phone, address, email);
    }

    @GetMapping("/getUser")
    public User GetUser(long Id) {
        return userService.GetUser(Id);
    }
}
