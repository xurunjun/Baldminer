package com.example.jpa;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

@Entity
public class Library {
    @Id
    @GeneratedValue
    private int id;
    private String name;

    @OneToMany(cascade = CascadeType.ALL,mappedBy = "library")
    private List<com.example.jpa.Book> bookList;
    public Library(){}
    public Library(String libraryName,
                   String bookId1, String anchor1, String bookName1, String price1, String publish1,
                   String bookId2, String anchor2, String bookName2, String price2, String publish2){
        this.name = libraryName;
        this.bookList = new ArrayList<>();
        com.example.jpa.Book book = new com.example.jpa.Book();
        book.setId(bookId1);
        book.setAnthor(anchor1);
        book.setBookname(bookName1);
        book.setPrice(price1);
        book.setPublish(publish1);
        book.setLibrary(this);
        this.bookList.add(book);
//        3?4?5?
        book = new com.example.jpa.Book();
        book.setId(bookId2);
        book.setAnthor(anchor2);
        book.setBookname(bookName2);
        book.setPrice(price2);
        book.setPublish(publish2);
        book.setLibrary(this);
        this.bookList.add(book);
    }

    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public List<com.example.jpa.Book> getBookList() {
        return bookList;
    }
    public void setBookList(List<com.example.jpa.Book> bookList) {
        this.bookList = bookList;
    }

}
