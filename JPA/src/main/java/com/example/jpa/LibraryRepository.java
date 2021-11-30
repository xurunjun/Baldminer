package com.example.jpa;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface LibraryRepository extends JpaRepository<Library,String> {
    public List<Library> findByBook_name(String bookName);
}
