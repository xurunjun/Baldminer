package com.example.jpa;

import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.*;
import java.util.List;

@Entity
public class Book {
    @Id
    @Column(columnDefinition = "varchar(50)")
    private String id;
    private String bookname;
    private String anthor;
    private String price;
    private String publish;
    @JsonIgnore
    @ManyToOne(cascade = CascadeType.ALL)
    private Library library;

    public String getId() {
        return id;
    }
    public void setId(String id) {
        this.id = id;
    }
    public String getBookname() {
        return bookname;
    }
    public void setBookname(String bookname) {
        this.bookname = bookname;
    }
    public String getAnthor() {
        return anthor;
    }
    public void setAnthor(String anthor) {
        this.anthor = anthor;
    }
    public String getPrice() {
        return price;
    }
    public void setPrice(String price) {
        this.price = price;
    }
    public String getPublish() {
        return publish;
    }
    public void setPublish(String publish) {
        this.publish = publish;
    }
    public Library getLibrary() {
        return library;
    }
    public void setLibrary(Library library) {
        this.library = library;
    }
}
