package com.example.jpa;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;


public interface BookRepository extends JpaRepository<Book,String>{
//    public String<Book> findByLibrary_name(String libraryname);
}
