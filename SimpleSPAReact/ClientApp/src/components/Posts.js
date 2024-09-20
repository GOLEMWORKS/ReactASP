import {useEffect, useState} from "react";

const URL = "/api/posts";
const Posts = () => {
    const [allPosts, setPosts] = useState([]);
    const getPosts = async () => {
        const options = {
            method: 'GET',
            headers: new Headers()
        }
        const response = await fetch(URL, options);
        if (response.ok){
            const posts = await response.json();
            setPosts(posts);
            return posts;
        }
        return [];
    }


    const addPost = async () => {

        const headerFromUser = document.querySelector('#header').value;
        const textFromUser = document.querySelector('#text').value;

        // Формирование поста
        const newPost = {
            header: headerFromUser,
            text: textFromUser
        };

        const headers = new Headers();
        headers.set('Content-Type', 'application/json');

        const options = {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(newPost)
        };

        const result = await fetch(URL, options);
        if (result.ok){
            const post = await result.json();
            allPosts.push(post);
            setPosts(allPosts.slice());
        }
    }


    useEffect(() => {
        getPosts();
    }, [])
    
    return (
        <div>
            <div>
                <p>Тут будут посты</p>
                <div style={{margin: "10px",}}>
                    <input type={"text"} id="header"></input>
                </div>
                <div style={{margin: "10px",}}>
                    <textarea id="text"></textarea>
                </div>
                <div style={{margin: "10px",}}>
                    <button onClick={() => addPost()}>Add post</button>
                </div>
            </div>
            <div>
                {allPosts.map(x => <PostItem key={x.id} id={x.id} header={x.header} text={x.text} />)}
            </div>
        </div>
    )
}

export default Posts;

const PostItem = ({id, header, text}) => {
    return (
        <div>
            <h2>{header}</h2>
            <p>{text}</p>
        </div>
    )
}