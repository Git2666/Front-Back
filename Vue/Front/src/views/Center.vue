<template>
    <div>
      <h1>Available Books</h1>
      <ul>
        <li v-for="book in books" :key="book">
          <a href="#" @click.prevent="downloadBook(book)">{{ book }}</a>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  import { ref, onMounted } from 'vue';
  import axios from 'axios';
  
  export default {
    setup() {
      const books = ref([]);
  
      // 获取所有书名
      const fetchBooks = async () => {
        try {
          const response = await axios.get('http://150.158.121.115:1080/api/Book/Glance');
          books.value = response.data;
        } catch (error) {
          console.error('Error fetching books:', error);
        }
      };
  
    // 下载文件并处理 token
    const downloadBook = async (filename) => {
      const url = `http://150.158.121.115:1080/api/Book/DownloadBook?filename=${filename}`;

      try {
        const response = await axios.get(url, {
          responseType: 'blob' // 将响应类型设置为 blob
        });

        // 创建 Blob URL 并下载文件
        const downloadUrl = window.URL.createObjectURL(new Blob([response.data]));
        const a = document.createElement('a');
        a.href = downloadUrl;
        a.download = filename;
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
        window.URL.revokeObjectURL(downloadUrl); // 释放 Blob URL
      } catch (error) {
        console.error('Error downloading book:', error);
      }
    }
  
      // 在组件挂载时获取书名
      onMounted(() => {
        fetchBooks();
      });
  
      return {
        books,
        downloadBook
      };
    }
  };
  </script>