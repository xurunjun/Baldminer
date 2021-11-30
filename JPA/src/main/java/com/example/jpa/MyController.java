package com.example.jpa;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.List;

@RestController
public class MyController {
    @Autowired
    private BookRepository bookRepository;
    public LibraryRepository libraryRepository;
    @RequestMapping("/find")
    public List<Book> find(){
        return LibraryRepository.findAll();
    }
    @RequestMapping("/init")
    public String initDb(){
        init();
        return "init OK";
    }

    void init(){
        List<Book> list = new ArrayList<>();
        Library library=new Library("King", "01", "TOM", "How to eat food", "10.0", "publishing1","02", "Jerry", "Jerry and Tom", "20.0", "publishing2");
        list.add(library);
        library=new Library("");
    }

}


