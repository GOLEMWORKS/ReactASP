import {useEffect, useState} from "react";

const Posts = () => {
    const [allPosts, setPosts] = useState([]);
    const getPosts = async () => {
        const options = {
            method: 'GET'
        }
        const response = await fetch("/api/posts", options);
        if (response.ok){
            const posts = await response.json();
            setPosts(posts);
            return posts;
        }
        return [];
    }
    
    useEffect(() => {
        getPosts();
    }, [])
    
    return (
        <div>
            <div>
                <p>Тут будут посты</p>
                <div style={{margin: "10px",}}>
                    <input type={"text"}></input>
                </div>
                <div style={{margin: "10px",}}>
                    <textarea></textarea>
                </div>
                <div style={{margin: "10px",}}>
                    <button>
                        Add Post
                    </button>
                </div>
            </div>
            <div>
                {allPosts.map(x => {
                    const postView = (
                        <div>
                            <h2>{x.header}</h2>
                            <p>{x.text}</p>
                        </div>
                    );
                    return postView;
                })}
            </div>
        </div>
    )
}

export default Posts;